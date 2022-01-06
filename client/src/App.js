import './App.css';
import React, { useState, useEffect } from 'react'
import PlayerBox from './components/PlayerBox';
import Map from './components/Map';
import { Row } from 'react-bootstrap';
import * as API from './AxiosRequest';

function App() {

  const [player, setPlayer] = useState(null)

  useEffect(async () => {
    await initPlayer()
  }, [])

  async function initPlayer() {
    let playerName = localStorage.getItem('playerName')

    if (playerName) {
      fetchPlayer(playerName)
    }
    else {
      createPlayer()
    }
  }

  async function fetchPlayer(playerName) {
    let res = await API.getPlayer(playerName)
    if (res != null){
      setPlayer(res.data)
    }
    else{
      //Player does not exist. Create a new one
      createPlayer()
    }
  }

  async function createPlayer() {
    let playerName = prompt("Skriv ditt nick", "Kenta");
    while (playerName.length < 1 || playerName.length > 20) {
      playerName = prompt("Ditt nick ska vara mellan 0 och 20 tecken långt!", "Duh");
    }
    let res = await API.createPlayer(playerName)
    localStorage.setItem('playerName', playerName)
    let playerRes = await API.getPlayer(playerName)
    setPlayer(playerRes.data)
  }

  //Triggers if player changes color
  async function updatePlayer() {
    let playerRes = await API.getPlayer(player.name)
    setPlayer(playerRes.data)
  }


  return (
    player ?
      <div className="App">
        <Row className="justify-content-md-center">
          <PlayerBox playername={player.name} playercolor={player.color} updateplayer={updatePlayer} />
        </Row>
        <Row className="justify-content-md-center mt-5">
          <Map playername={player.name}/>
        </Row>
      </div>
      :
      null

  );
}

export default App;
