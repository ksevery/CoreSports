import * as React from 'react';

import MarketHolder from '../MarketHolder/MarketHolder';
import Path from '../Path/Path';

class RootComponent extends React.Component {
  public render() {
    return (
        <div>
            <Path />
            <MarketHolder />
        </div>
    );
  }
}

export default RootComponent;
