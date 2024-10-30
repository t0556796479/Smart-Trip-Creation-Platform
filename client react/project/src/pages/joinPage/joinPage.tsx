import { useState, ChangeEvent, FormEvent } from 'react';
import { Container, TextField, Button, Typography, Grid } from '@mui/material';
import { UserType } from '../../types/user.types';
import { addUser } from '../../services/users.service';
import { useAppDispatch } from '../../redux/store';
import { setUser as setUserUser } from '../../redux/user/user.slice';
import { setUser as setUserAuth } from '../../redux/auth/auth.slice';
import { useNavigate } from 'react-router-dom';
import SuccessAlert from '../../components/alert/successAlert';
import ErrorAlert from '../../components/alert/errorAlert';


export default function Join() {

    const [user, setUser] = useState<Omit<UserType, 'userId'>>({
        name: '',
        email: '',
        password: '',
        userName: '',
        role: 'user'
    });

    const [error, setError] = useState<string>('');
    const [errorAlert, setErrorAlert] = useState<string>('');
    const [successAlert, setSuccessAlert] = useState<string>('');

    const navigate = useNavigate();
    const dispatch = useAppDispatch();

    const handleChange = (event: ChangeEvent<HTMLInputElement>) => {
        const { name, value } = event.target;
        setUser({ ...user, [name]: value });
    };

    const handleSubmit = async (event: FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        // בדיקת שדות חובה
        if (!user.name || !user.email || !user.password || !user.userName) {
            setError('כל השדות הם שדות חובה');
            return;
        }
        try {
            const new_user = await addUser(user);
            dispatch(setUserUser(new_user));
            dispatch(setUserAuth(new_user));
            setSuccessAlert('The user has successfully registered');

        } catch (error) {
            setErrorAlert('There was an error in the registration, try again');
            console.error('Error sending data:', error);
        }

        setUser({ name: '', email: '', password: '', userName: '', role: 'user' });
        setError('');
    };

    return (
        <Container maxWidth="sm">
            <Typography variant="h5" gutterBottom textAlign={'center'}>
                What a pleasure you joined us
            </Typography>
            <form onSubmit={handleSubmit}>
                <Grid container spacing={3}>
                    <Grid item xs={12}>
                        <TextField
                            label="full name"
                            name="name"
                            value={user.name}
                            onChange={handleChange}
                            fullWidth
                            required
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <TextField
                            label="email"
                            name="email"
                            type="email"
                            value={user.email}
                            onChange={handleChange}
                            fullWidth
                            required
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <TextField
                            label="password"
                            name="password"
                            type="password"
                            value={user.password}
                            onChange={handleChange}
                            fullWidth
                            required
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <TextField
                            label="user name"
                            name="userName"
                            value={user.userName}
                            onChange={handleChange}
                            fullWidth
                            required
                        />
                    </Grid>
                    {error && (
                        <Grid item xs={12}>
                            <Typography variant="body2" color="error">
                                {error}
                            </Typography>
                        </Grid>
                    )}
                    <Grid item xs={12}>
                        <Button type="submit" variant="contained" color="primary" fullWidth>
                            join us
                        </Button>
                    </Grid>
                </Grid>
                {successAlert && (< SuccessAlert text={successAlert} />)}
                {errorAlert && (< ErrorAlert text={errorAlert} />)}
            </form>
        </Container>
    );
};


