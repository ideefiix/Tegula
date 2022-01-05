import React from 'react'
import { Card } from 'react-bootstrap'

const PlayerBox = (props) => {
    return (
        <Card className='mt-3' style={{ width: '18rem' }}>
            <Card.Title>{props.playerName}</Card.Title>
            <Card.Body>
            <Card.Text>Färg: Grön </Card.Text> 
            </Card.Body>
        </Card>
    )
}

export default PlayerBox
