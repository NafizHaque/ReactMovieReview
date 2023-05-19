import React, { Component } from 'react';


interface MoviesProps {
  
}
 
const Movies  = (MoviesProps: any): JSX.Element => {
  return ( 
    <div>
      <h1>Hello, world!</h1>
      <p>Welcome to your new single-page application, built with:</p>
      <ul>
        <li><a href='https://get.asp.net/'>ASP.NET Core</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> for cross-platform server-side code</li>
        <li><a href='https://facebook.github.io/react/'>React</a> for client-side code</li>
        <li><a href='http://getbootstrap.com/'>Bootstrap</a> for layout and styling</li>
      </ul>
      <p>To help you get started, we have also set up:</p>
    </div>
  );
}
 
export default Movies;