import 'office-ui-fabric-react/dist/css/fabric.css';

import { initializeIcons, Nav, Text } from '@fluentui/react';
import About from 'app/pages/about/About';
import Groups from 'app/pages/groups/Groups';
import Home from 'app/pages/home/Home';
import React from 'react';
import Example from 'app/pages/example/Example';
import { BrowserRouter, Route } from 'react-router-dom';

import * as serviceWorker from '../serviceWorker';
import styles from './App.module.scss';

initializeIcons();

const App: React.FC = () => {
    return (
        <BrowserRouter>
            <React.Fragment>
                <div className="ms-Grid" dir="ltr">
                    <div className="ms-Grid-row">
                        <div className={styles.header}>
                            <Text className={styles.headerTitle}>AAS</Text>
                            <div className={styles.headerDivider} />
                            <Text className={styles.headerTitle}>Automated Appointment Scheduler</Text>
                        </div>
                        <div className={'ms-Grid-col ms-sm12 ms-lg4 ms-xl2'}>
                            <Nav
                                groups={[
                                    {
                                        collapseAriaLabel: 'Collapse',
                                        expandAriaLabel: 'Expand',
                                        links: [
                                            {
                                                name: 'Home',
                                                url: '/',
                                                key: 'home'
                                            },
                                            {
                                                name: 'About',
                                                url: '/about',
                                                key: 'about'
                                            },
                                            {
                                                name: 'Groups',
                                                url: '/groups',
                                                key: 'groups'
                                            },
                                            {
                                                name: 'Example',
                                                url: '/example',
                                                key: 'example'
                                            }
                                        ]
                                    }
                                ]}
                            />
                        </div>
                        <div className="ms-Grid-col ms-sm12 ms-lg8 msxl-10">
                            <Route path="/" exact component={Home} />
                            <Route path="/about" component={About} />
                            <Route path="/groups" component={Groups} />
                            <Route path="/example" exact component={Example} />
                        </div>
                    </div>
                </div>
            </React.Fragment>
        </BrowserRouter>
    );
};

export default App;

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
