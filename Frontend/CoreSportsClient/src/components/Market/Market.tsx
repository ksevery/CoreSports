import * as React from 'react';
import  { Panel } from 'react-bootstrap';
import Selection from '../Selection/Selection';
class Market extends React.Component {
        
  public render() {

    return (
        <div>
            <Panel>
            <Panel.Heading>Match result</Panel.Heading>
            <Panel.Body>
              <Selection />
            </Panel.Body>
            </Panel>
        </div>
    );
  }
}

export default Market;
