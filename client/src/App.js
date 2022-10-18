import * as React from "react";
import "./App.css";

import {BrowserRouter as Router, Route, Routes} from 'react-router-dom';

import Dashboard from './pages/Dashboard';
import Registration from './pages/Registration'
import Login from './pages/Login'
import Department from "./pages/Departments"


function App() {
  return (
    <div className="App">
      <Router>
        <div>
          {/* 👇️ Wrap your Route components in a Routes component */}
          <Routes>
            <Route path="/" element={<Login />} />
            <Route path="/Registration" element={<Registration />} />
            <Route path="/DashBoard" element={<Dashboard />} />
            <Route path="/Department" element={<Department />} />
            
          </Routes>
        </div>
      </Router>
    </div>
  );
}

export default App;
