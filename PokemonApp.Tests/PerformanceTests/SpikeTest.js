import http from 'k6/http';
import { sleep } from 'k6';

export let options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,
    stages: [
        { duration: '10s', target: 100 }, // below normal load
        { duration: '1m', target: 100 },
        { duration: '10s', target: 1400 }, // spike of 1400 users
        { duration: '2m', target: 1400 },  // stay at 1400 users for some time
        { duration: '10s', target: 100 }, // scale down
        { duration: '3m', target: 100 },
        { duration: '10s', target: 0 }, 
    ]
};

const API_BASE_URL = 'http://localhost:5099/api/pokemon'

export default () => {
    http.batch([
        ['GET', `${API_BASE_URL}/1`],
        ['GET', `${API_BASE_URL}/543`],
        ['GET', `${API_BASE_URL}/789`],
    ]);

    sleep(1);
}