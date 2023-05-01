import React, { Component } from 'react';
import { Outlet } from 'react-router-dom';

const Layout = (): JSX.Element => {
  return (

    <div style= {{ color: 'blue', border: "2px",width:"500px", height:"500px", borderStyle:'dotted' }}>
      <Outlet />
    </div>

  );
}
export default Layout;



