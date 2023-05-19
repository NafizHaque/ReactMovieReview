import React, { Component, useEffect } from 'react';
import { useState } from 'react';
import { NavLink, Outlet } from 'react-router-dom';
import "../stylesheets/RootLayout.css"
import { FetchMovies } from '../../Api/Variables';


const RootLayout = (): JSX.Element => {
  const [movies, setMovies] = useState<any[]>([]);

  useEffect(() => {
    FetchMovies()
      .then(FetchMovies => {
        setMovies(FetchMovies);
      })
      .catch(error => {
        console.error("Error fetching movies", error);
      });

  }, []);
  return (
    <div className='root-layout'>
      <header>
        <nav>
        <ul>
          <li><NavLink  to="/">Home</NavLink></li>
          <li><NavLink to="/movie">Movies</NavLink></li>
          <li><NavLink to="/">Contacts</NavLink></li>
          <li><NavLink to="/">About</NavLink></li>
        </ul>
        </nav>
      </header>
      <main>
        <Outlet />
      </main>
    </div>
  );
}
export default RootLayout;



