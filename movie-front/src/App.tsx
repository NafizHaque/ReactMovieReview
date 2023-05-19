import React from 'react';
import { Route, RouterProvider, Routes, createBrowserRouter, createRoutesFromElements } from 'react-router-dom';
//pages
import Home from './pages/Home';
import Movies from './pages/Movies';
//layouts
import RootLayout from './components/layouts/RootLayout';
//css
import './App.css';


const router = createBrowserRouter(
    createRoutesFromElements(
      <Route path="/" element={<RootLayout />}>
        <Route index element = {<Home />} />
        <Route path='/movie' element = {<Movies />} />
      </Route>
    )
)


function App() {
  return (
    <RouterProvider router={router} />
  );
}

export default App;
