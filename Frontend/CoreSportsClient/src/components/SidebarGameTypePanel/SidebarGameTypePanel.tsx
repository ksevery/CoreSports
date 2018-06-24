import * as React from 'react';
import './SidebarGameTypePanel.css';

import {Panel} from 'react-bootstrap'; 

class SidebarGameTypePanel extends React.Component {




  public render() {
    return (
      <div>
        <Panel>
          <Panel.Heading>Panel heading without a title</Panel.Heading>
          <Panel.Body>Panel content</Panel.Body>
        </Panel>
        <Panel>
          <Panel.Heading>
            <Panel.Title componentClass="h3">Panel heading with a title</Panel.Title>
          </Panel.Heading>
          <Panel.Body>Panel content</Panel.Body>
        </Panel>
      </div>
    );
  }
}

export default SidebarGameTypePanel;
