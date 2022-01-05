import React, { useState, useEffect } from 'react'
import { Card, Figure, Col, Row } from 'react-bootstrap'
import { fetchTiles } from '../AxiosRequest'
import './style.css'

const Map = () => {
    const [tiles, setTiles] = useState([])

    useEffect(() => {
        getTiles()
        /* let tiles = [{ id: 1, owner: "Fille", color: "#a83246" }, { id: 2, owner: "Oskar", color: "#a83246" }, { id: 3, owner: "Emil", color: "#a83246" }, { id: 4, owner: "Bruh", color: "#a83246" },
         { id: 5, owner: "Larsson", color: "#a83246" }]
        setTiles(tiles) */
    }, [])

    async function getTiles() {
        let tileResponse = await fetchTiles()
        setTiles(tileResponse.data)
        console.log(tileResponse.data);
    }

    return (
        <Row id="mapContainer" className='justify-content-center'>
            {
                tiles.map(tile => {
                    return (
                        <div className='' style={{ width: '110px', height: '100px', backgroundColor: tile.color }}>
                            <h5>Område {tile.id}</h5>
                            <p style={{ overflow: 'hidden' }}>test</p>
                        </div>)

                })
            }
        </Row>

    )
}

export default Map
