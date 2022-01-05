import axios from "axios";

axios.defaults.baseURL = process.env.REACT_APP_SERVER_BASE_URL ? process.env.REACT_APP_SERVER_BASE_URL : "https://localhost:7190";
// TOKEN IMPLEMENT LATER
/* axios.interceptors.request.use(function (config) {
    const token = `Bearer ${sessionStorage.getItem('AUTH_TOKEN')}`;
    config.headers.Authorization = token;

    return config;
}); */
axios.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded';

export async function fetchTiles(){
    let response = await axios.get(`/tile`)
        .then(res => {
            return res
        })
        .catch(e => {
            console.log("Error: " + e);
        })
    return response;
}

export async function fetchTile(tileId){
    let response = await axios.get(`/tile/${tileId}`)
        .then(res => {
            return res
        })
        .catch(e => {
            console.log("Error: " + e);
        })
    return response;
}

export async function attackTile(tileId, attackerName){
    const data = {
        name: attackerName
    }
    let response = await axios.put(`/tile/attack/${tileId}`, data)
        .then(res => {
            return res
        })
        .catch(e => {
            console.log("Error: " + e);
        })
    return response;
}

export async function createPlayer(playerName){
    const data = {
        name: playerName
    }
    let response = await axios.post(`/player`, data)
        .then(res => {
            return res
        })
        .catch(e => {
            console.log("Error: " + e);
        })
    return response;
}

export async function getPlayer(playerName){
    let response = await axios.get(`/player/${playerName}`)
    .then(res => {
        return res
    })
    .catch(e => {
        console.log(e);
        return null
    })
    return response;
}

export async function changeColor(playerName, color){
    const data = {
        name: playerName,
        color: color
    }

    let response = await axios.put(`/player/changecolor`, data)
    .then(res => {
        return res
    })
    .catch(e => {
        console.log("Error: " + e);
    })
    return response;
}