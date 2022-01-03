import './App.css';
import PlayerBox from './components/PlayerBox';
import Map from './components/Map';
import { Row } from 'react-bootstrap';

function App() {
  return (
    <div className="App">
      <Row className="justify-content-md-center">
      <PlayerBox className=""/>
      </Row>
      <Row className="justify-content-md-center mt-5">
      <Map/>
      </Row>
    </div>
  );
}

export default App;
