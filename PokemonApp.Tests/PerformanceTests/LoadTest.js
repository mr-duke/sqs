import http from 'k6/http';
import { sleep } from 'k6';

export let options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,
    stages: [
        { duration: '30s', target: 100 }, // continuous ramp-up from 1 to 100 users
        { duration: '1m', target: 100 }, // stay at 100 users for some time
        { duration: '30s', target: 0 }, // scale down
    ],
    thresholds: {
        http_req_failed: ['rate<0.02'], // http errors should be less than 2%
        http_req_duration: ['p(95)<150'], // 95 % of requests must finish below 150 ms
    },
};

export default () => {

    let response = http.get(`http://localhost:5099/api/pokemon/1`)

    sleep(1);
}