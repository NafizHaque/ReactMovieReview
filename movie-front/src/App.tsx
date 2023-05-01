import React from 'react';
import { Route, Routes, BrowserRouter } from 'react-router-dom';
import logo from './logo.svg';
import Home from './pages/Home';
import Movies from './pages/Movies';
import Layout from './components/Layout';
import './App.css';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element = {<Home />} />
        <Route path='/movie' element = {<Movies />} />

        <Route path='/layout' element ={<Layout/>}>
          <Route index  element = {<Home />} />
        </Route>
      </Routes>
    </BrowserRouter>
   
  );
}

export default App;
