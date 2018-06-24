import * as React from 'react';
import Market from '../Market/Market';

 class MarketHolder extends React.Component {
        
  public render() {

    return (
        <div>
            <Market />
            <Market />
            <Market />
        </div>
    );
  }
}

export default MarketHolder;
