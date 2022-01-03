import React, { useState, useEffect } from 'react'
import { Card, Figure, Col, Row} from 'react-bootstrap'
import './style.css'

const Map = () => {
    const [map, setmap] = useState([])

    useEffect(() => {
        let tiles = [{ id: 1, owner: "Fille", color: "#a83246" }, { id: 2, owner: "Oskar", color: "#a83246" }, { id: 3, owner: "Emil", color: "#a83246" }, { id: 4, owner: "Bruh", color: "#a83246" },
         { id: 5, owner: "Larsson", color: "#a83246" }]
        setmap(tiles)
    }, [])

    return (
        <Row id="mapContainer" className='justify-content-center'>
            {
                map.map(tile => {
                    return (
                    <div className='' style={{ width: '110px', height: '100px', backgroundColor: tile.color }}>
                        <h5>Område {tile.id}</h5>
                        <p style={{overflow: 'hidden'}}>test</p>
                    </div>)
                    
                })
            }
        </Row>

    )
}

export default Map
