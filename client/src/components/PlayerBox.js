import React, { useState, useEffect } from 'react'
import { Card } from 'react-bootstrap'
import { SketchPicker } from 'react-color'
import * as API from '../AxiosRequest';

const PlayerBox = (props) => {
    const [showColorPicker, setshowColorPicker] = useState(false)
    const [playerColor, setplayerColor] = useState(props.playerColor)

    function handleColorChange(color){
        setplayerColor(color.hex)
    }

    async function savePlayerColor(){
        setshowColorPicker(false)
        let res = await API.changeColor(props.playerName, playerColor)
        props.updatePlayer()
    }

    return (
        <Card className='mt-3' style={{ width: '18rem' }}>
            <Card.Title>{props.playerName}</Card.Title>
            <Card.Body>

            {
            showColorPicker ?
            <>
            <Card.Text onClick={() => savePlayerColor()} className='colorLink' style={{color: playerColor}}>Spara färg</Card.Text> 
             <SketchPicker color={playerColor} onChangeComplete={handleColorChange}/>
            </>
             :
             <Card.Text>Välj <span onClick={() => setshowColorPicker(!showColorPicker)} className='colorLink' style={{color: playerColor}}>färg</span> </Card.Text> 
            }

            </Card.Body>
        </Card>
    )
}

export default PlayerBox
