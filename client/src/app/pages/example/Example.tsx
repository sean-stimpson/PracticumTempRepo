import React from 'react';
import { TextField, PrimaryButton } from '@fluentui/react';
import { ApiClient, BusinessDto } from 'app/generated/backend';

interface IState {
    name: string;
    address: string;
    username: string;
    password: string;
    phoneNumber: string;
    field: string;
    createdMsg: string;
}

export default class Example extends React.Component<{}, IState> {
    constructor(props: any) {
        super(props);
        this.state = {
            name: '',
            address: '',
            username: '',
            password: '',
            phoneNumber: '',
            field: '',
            createdMsg: ''
        };
    }

    onNewBusNameChange(e: any) {
        this.setState({
            name: e
        });
    }

    onNewBusAddressChange(e: any) {
        this.setState({
            address: e
        });
    }

    onNewBusPasswordChange(e: any) {
        this.setState({
            password: e
        });
    }

    onNewBusPhoneNumberChange(e: any) {
        this.setState({
            phoneNumber: e
        });
    }

    onNewBusUsernameChange(e: any) {
        this.setState({
            username: e
        });
    }
    onNewBusFieldChange(e: any) {
        this.setState({
            field: e
        });
    }

    async onNewBusinessSubmit(e: any) {
        e.preventDefault();
        let dto = new BusinessDto();
        dto.init({
            username: this.state.username,
            password: this.state.password,
            businessName: this.state.name,
            field: this.state.field,
            address: this.state.address,
            phoneNumber: this.state.phoneNumber
        });
        console.log(dto);
        let api = await new ApiClient(process.env.REACT_APP_API_BASE).business_CreateBusiness(dto);
        if (api !== undefined) {
            this.setState({
                createdMsg: 'Business Created'
            });
        }
    }

    render() {
        return (
            <div>
                <h2>Create a Business</h2>
                {console.log(this.state)}
                <TextField label="Username" onChange={(e, text) => this.onNewBusUsernameChange(text)}></TextField>
                <TextField label="Password" onChange={(e, text) => this.onNewBusPasswordChange(text)} />
                <TextField label="Business Name" onChange={(e, text) => this.onNewBusNameChange(text)} />
                <TextField label="Field" onChange={(e, text) => this.onNewBusFieldChange(text)} />
                <TextField label="Address" onChange={(e, text) => this.onNewBusAddressChange(text)} />
                <TextField label="Phone Number" onChange={(e, text) => this.onNewBusPhoneNumberChange(text)} />
                <PrimaryButton onClick={(e) => this.onNewBusinessSubmit(e)}>Submit</PrimaryButton>
                <h2>{this.state.createdMsg}</h2>
            </div>
        );
    }
}
