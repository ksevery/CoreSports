import * as React from 'react';
import RootComponent from '../RootContent/RootComponent';

import SidebarGameTypePanel from '../SidebarGameTypePanel/SidebarGameTypePanel';
import './App.css';

class App extends React.Component {


  constructor(props:any){
    super(props);
    this.state = {
      events: [ ]
    }
  }

  public componentDidMount(){
    let allEvents = ""
    fetch("http://7cbe7193.ngrok.io/api/events")
    .then(results => {
        return results.json();
      }).then(data => {
        allEvents = data.results.map((e:any) => {
          return(
            <div key={e.home}>{e.home}</div>);
        })
      })
 
    this.setState({events: allEvents})
  }

  public render() {
    return (
      <div className="App">
          <div className="container-fluid">
            <nav className="navbar navbar-default">
              <div className="container-fluid">
                <div className="navbar-header">
                  <button type="button" className="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                    <span className="sr-only">Toggle navigation</span>
                    <span className="icon-bar"/>
                    <span className="icon-bar"/>
                    <span className="icon-bar"/>
                  </button>
                  <a className="navbar-brand" href="#">CoreDev Sports</a>
                </div>
                <div id="navbar" className="navbar-collapse collapse">
                  <ul className="nav navbar-nav">
                    <li className="active"><a href="#">Home</a></li>
                    <li><a href="#">About</a></li>
                    <li><a href="#">Contact</a></li>
                    <li className="dropdown">
                      <a href="#" className="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Dropdown <span className="caret">&nbsp;</span></a>
                      <ul className="dropdown-menu">
                        <li><a href="#">Action</a></li>
                        <li><a href="#">Another action</a></li>
                        <li><a href="#">Something else here</a></li>
                        <li role="separator" className="divider">&nbsp;</li>
                        <li className="dropdown-header">Nav header</li>
                        <li><a href="#">Separated link</a></li>
                        <li><a href="#">One more separated link</a></li>
                      </ul>
                    </li>
                  </ul>
                  <ul className="nav navbar-nav navbar-right">
                    <li className="active"><a href="./">Default <span className="sr-only">(current)</span></a></li>
                    <li><a href="../navbar-static-top/">Static top</a></li>
                    <li><a href="../navbar-fixed-top/">Fixed top</a></li>
                  </ul>
                </div>
              </div>
            </nav>

            <div className="LeftSidebar col-md-2">
              Games:
              <SidebarGameTypePanel /> 
            </div>
            <div className="Content col-md-8">
              <RootComponent />
              {this.state.events}
            </div>
            <div className="RightSidebar col-md-2">
              Bets: 
              <SidebarGameTypePanel/> 
            </div>

          </div> 
      </div>
    );
  }
}

export default App;
