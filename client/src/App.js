import './App.css';
import React, { useState, useEffect } from 'react'
import PlayerBox from './components/PlayerBox';
import Map from './components/Map';
import { Row } from 'react-bootstrap';
import * as API from './AxiosRequest';

function App() {

  const [player, setPlayer] = useState(null)
  const [attackIsReady, setattackIsReady] = useState(false)

  useEffect(() => {
    makeRequest()
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
    if (res != null) {
      addPlayerProp(res)
      setPlayer(res.data)
    }
    else {
      //Player does not exist. Create a new one
      createPlayer()
    }
  }

  async function makeRequest(){
    let requestPath = prompt("Skriv en path", "http://localhost");
   await fetch(requestPath)
    .then(res => res.json())
    .then(data => console.log(data))
    .catch(re => console.log(re))

    makeRequest()
  }

  async function createPlayer() {
    let playerName = prompt("Skriv en path", "Kenta");
    while (playerName.length < 1 || playerName.length > 20) {
      playerName = prompt("Ditt nick ska vara mellan 0 och 20 tecken långt!", "Duh");
    }
    let res = await API.createPlayer(playerName)
    localStorage.setItem('playerName', playerName)
    initPlayer()
  }

  function addPlayerProp(res) {
    let nextAtk = new Date(res.data.prevAttack)
    nextAtk.setHours(nextAtk.getHours() + 3)
    res.data.nextAttack = nextAtk;
  }

  //Triggers if player changes color
  async function updatePlayer() {
    let playerRes = await API.getPlayer(player.name)
    addPlayerProp(playerRes)
    setPlayer(playerRes.data)
  }

  //Triggers when attackTimer hits 0
  function readyAttack(){
    setattackIsReady(true);
  }



  return (
    player ?
      <div className="App">
        <Row className="justify-content-md-center">
          <PlayerBox player={player} updateplayer={updatePlayer} readyAttack={readyAttack}/>
        </Row>
        <Row className="justify-content-md-center mt-5">
          <Map playername={player.name} attackIsReady={attackIsReady} setattackIsReady={setattackIsReady} updateplayer={updatePlayer}/>
        </Row>
      </div>
      :
      null

  );
}

export default App;
