import './App.css';
import React, { useState, useEffect } from 'react'
import PlayerBox from './components/PlayerBox';
import Map from './components/Map';
import { Row } from 'react-bootstrap';
import { fetchTiles } from './AxiosRequest';

function App() {

  const [playerName, setplayerName] = useState("")
  useEffect(async () => {
    await initPlayerName()
  }, [])

  async function initPlayerName() {
    let playerName = localStorage.getItem('playerName')

    if (playerName){
      setplayerName(playerName)
    }
    else{
      playerName = prompt("Skriv ditt nick", "Kenta");
      while (playerName.length < 1 || playerName.length > 20){
        playerName = prompt("Ditt nick ska vara mellan 0 och 20 tecken långt!", "Duh");
      }
      localStorage.setItem('playerName', playerName)
      localStorage.setItem('playerColor', '#033dfc')
      setplayerName(playerName)
    }
  }
 

  return (
    playerName ?
    <div className="App">
      <Row className="justify-content-md-center">
        <PlayerBox playerName={playerName} />
      </Row>
      <Row className="justify-content-md-center mt-5">
        <Map />
      </Row>
    </div>
    :
    null
    
  );
}

export default App;
