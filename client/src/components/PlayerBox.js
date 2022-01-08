import React, { useState, useEffect } from 'react'
import { Card } from 'react-bootstrap'
import { SketchPicker } from 'react-color'
import { useTimer } from 'react-timer-hook';
import * as API from '../AxiosRequest';

const PlayerBox = (props) => {
    const [showColorPicker, setshowColorPicker] = useState(false)
    const [playerColor, setplayerColor] = useState(props.player.color)
    // a Date object
    const [attackTimer, setAttackTimer] = useState(null)

    useEffect(() => {
        let timeLeft = props.player.nextAttack - new Date()
        if (timeLeft > 0) {
            setAttackTimer(props.player.nextAttack)
        }else{
            props.readyAttack()
        }
    }, [props.player])

    function AttackTimer({ expiryTimestamp }) {
        useEffect(() => {
        }, [])
        const {
            seconds,
            minutes,
            hours
        } = useTimer({ expiryTimestamp, onExpire: () => timerExpired() });

        return (
            <>
            <Card.Text className='mb-0'>Du kan anfalla igen om:</Card.Text>
            <Card.Text>{hours}h {minutes}min {seconds}sek</Card.Text>
            </>
        )

    }

    function timerExpired() {
        setAttackTimer(null)
        props.readyAttack()
    }

    function handleColorChange(color) {
        setplayerColor(color.hex)
    }

    async function savePlayerColor() {
        setshowColorPicker(false)
        let res = await API.changeColor(props.player.name, playerColor)
        props.updateplayer()
    }

    return (
        <Card className='mt-3' style={{ width: '18rem' }}>
            <Card.Title>{props.player.name}</Card.Title>
            <Card.Body>

                {
                    attackTimer ?
                        <AttackTimer expiryTimestamp={attackTimer} />
                        :
                        <Card.Text>Du kan anfalla</Card.Text>
                }

                {
                    showColorPicker ?
                        <>
                            <Card.Text onClick={() => savePlayerColor()} className='colorLink' style={{ color: playerColor }}>Spara färg</Card.Text>
                            <SketchPicker color={playerColor} onChangeComplete={handleColorChange} />
                        </>
                        :
                        <Card.Text>Välj <span onClick={() => setshowColorPicker(!showColorPicker)} className='colorLink' style={{ color: playerColor }}>färg</span> </Card.Text>
                }

            </Card.Body>
        </Card>
    )
}

export default PlayerBox
