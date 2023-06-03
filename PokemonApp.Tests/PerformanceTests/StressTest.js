﻿import http from 'k6/http';
import { sleep } from 'k6';

export let options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,
    stages: [
        { duration: '2m', target: 100 }, // below normal load
        { duration: '5m', target: 100 },
        { duration: '2m', target: 200 }, // normal load
        { duration: '5m', target: 200 },
        { duration: '2m', target: 300 }, // probably around the breaking point
        { duration: '5m', target: 300 },
        { duration: '2m', target: 400 }, // probably beyond the breaking point
        { duration: '5m', target: 400 },
        { duration: '10m', target: 0 },  // scale down
    ]};

const API_BASE_URL = 'http://localhost:5099/api/pokemon'

export default () => {
    http.batch([
        ['GET', `${API_BASE_URL}/1`],
        ['GET', `${API_BASE_URL}/543`],
        ['GET', `${API_BASE_URL}/789`],
    ]);

    sleep(1);
}