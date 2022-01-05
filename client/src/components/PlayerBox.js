import React, { useState, useEffect } from 'react'
import { Card } from 'react-bootstrap'
import { SketchPicker } from 'react-color'

const PlayerBox = (props) => {
    const [showColorPicker, setshowColorPicker] = useState(false)
    const [playerColor, setplayerColor] = useState("#033dfc")

    useEffect(() => {
        let storageColor = localStorage.getItem('playerColor')
        if (storageColor){
            setplayerColor(storageColor)
        }
    }, [])

    function handleColorChange(color){
        localStorage.setItem('playerColor', color.hex)
        setplayerColor(color.hex)
    }
    return (
        <Card className='mt-3' style={{ width: '18rem' }}>
            <Card.Title>{props.playerName}</Card.Title>
            <Card.Body>
            <Card.Text>Välj <span onClick={() => setshowColorPicker(!showColorPicker)} className='colorLink' style={{color: playerColor}}>färg</span> </Card.Text> 
            {
            showColorPicker ?
             <SketchPicker color={playerColor} onChangeComplete={handleColorChange}/>
             :
             null
            }
            </Card.Body>
        </Card>
    )
}

export default PlayerBox
