import http from 'k6/http';
import { sleep } from 'k6';

export let options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,
    stages: [
        { duration: '2m', target: 400 }, // ramp up to 400 users
        { duration: '4h', target: 400 }, // stay at 400 users for a long time
        { duration: '2m', target: 0 }, // scale down again
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