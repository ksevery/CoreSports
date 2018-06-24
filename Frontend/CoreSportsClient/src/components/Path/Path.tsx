import * as React from 'react';
import  { Breadcrumb } from 'react-bootstrap';

import './Path.css';
class Path extends React.Component {
        
  public render() {

    return (
      <div className="Path">
        <Breadcrumb>
            <Breadcrumb.Item href="#">Home</Breadcrumb.Item>
            <Breadcrumb.Item href="http://getbootstrap.com/components/#breadcrumbs">
                Library
            </Breadcrumb.Item>
            <Breadcrumb.Item>Data</Breadcrumb.Item>
        </Breadcrumb>
      </div>
    );
  }
}

export default Path;
