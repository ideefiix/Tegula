import React, { useState, useEffect } from 'react'
import { Card, Figure, Col, Row, Button } from 'react-bootstrap'
import * as API from '../AxiosRequest';
import './style.css'

const Map = (props) => {
    const [tiles, setTiles] = useState([])
    const [selectedTile, setSelectedTile] = useState(null)

    useEffect(() => {
        getTiles()
        /* let tiles = [{ id: 1, owner: "Fille", color: "#a83246" }, { id: 2, owner: "Oskar", color: "#a83246" }, { id: 3, owner: "Emil", color: "#a83246" }, { id: 4, owner: "Bruh", color: "#a83246" },
         { id: 5, owner: "Larsson", color: "#a83246" }]
        setTiles(tiles) */
    }, [])

    async function getTiles() {
        let tileResponse = await API.fetchTiles()
        tileResponse.data.sort((a, b) => (a.id > b.id) ? 1 : -1)
        setTiles(tileResponse.data)
    }

    async function selectTile(tileId){
        let res = await API.fetchTile(tileId);
        setSelectedTile(res.data)

    }

    async function attackTile(id, attackerName){
        await API.attackTile(id, attackerName)
        props.updateplayer()
        props.setattackIsReady(false)
        getTiles()
    }


    return (
        <Row id="mapContainer" className='justify-content-center'>
            {
                tiles.map(tile => {
                    return (
                        <div onClick={() => selectTile(tile.id)} className='tile' style={{ width: '110px', height: '100px', backgroundColor: tile.color, cursor: 'pointer' }} key={tile.id}>
                            <h5>Område {tile.id}</h5>
                            <p style={{ overflow: 'hidden' }}>{tile.ownerId}</p>
                        </div>)

                })
            }

            {selectedTile === null ? 
            null
            :
            <Card className='mt-5' style={{ width: '18rem' }}>
                <Card.Title>Område {selectedTile.id}</Card.Title>
                <Card.Body>
                    <Card.Text>Ägs av <b>{selectedTile.ownerId}</b></Card.Text>
                    <Button disabled={!props.attackIsReady} onClick={() => attackTile(selectedTile.id, props.playername)}>Erövra</Button>
                </Card.Body>
            </Card>
            }
        </Row>

    )
}

export default Map
