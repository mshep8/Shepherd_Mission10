/*
Mary Catherine Shepherd
IS 413
Mission 10

Main React application file.
Displays the heading and bowler table components.
*/

import "./App.css";
import Heading from "./components/Heading";
import BowlerList from "./components/BowlerList";

function App() {
  return (
    <div>
      <Heading />
      <BowlerList />
    </div>
  );
}

export default App;
