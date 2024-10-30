
import { Box, Button, Grid, Link, Typography, createTheme } from "@mui/material";
import EmailInput from "../../components/form/emailInput";
import PasswordInput from "../../components/form/passwordInput";
import { login as loginApi } from "../../services/users.service";
import { setSession } from "../../auth/auth.utils";
import { ChangeEvent, useState } from "react";
import { useAppDispatch } from "../../redux/store";
import { setUser as setUserAuth } from '../../redux/auth/auth.slice';
import { setUser } from '../../redux/user/user.slice';
import { LoginUserType } from "../../types/auth.type";
import { PATHS } from "../../routes/paths";
import { Send as SendIcon } from "@mui/icons-material";
import { getUserById } from "../../services/users.service";
import { useNavigate } from "react-router-dom";
import SuccessAlert from "../../components/alert/successAlert";

export default function Login() {


    const [loginUser, setLoginUser] = useState<LoginUserType>({ email: '', password: '' });
    const [emailError, setEmailError] = useState('');
    const [passwordError, setPasswordError] = useState('');
    const [loginError, setLoginError] = useState('');
    const [registerError, setRegisterError] = useState('');

    const [successAlert, setSuccessAlert] = useState<string>('');


    const dispatch = useAppDispatch();
    const navigate = useNavigate();

    const handleChange = (event: ChangeEvent<HTMLInputElement>) => {

        const { name, value } = event.target;
        setLoginUser({ ...loginUser, [name]: value });
    }


    const handleSubmit = async (event: React.MouseEvent<HTMLButtonElement, MouseEvent>) => {
        event.preventDefault();
        if (loginUser.email.trim() === '' || loginUser.password.trim() === '') {
            if (loginUser.password.trim() === '') {
                setPasswordError('Required field');
            }
            if (loginUser.email.trim() === '') {
                setEmailError('Required field');
            }
        }
        else {
            setPasswordError('');
            setEmailError('');
            try {

                const authUser = await loginApi(loginUser.email, loginUser.password);
                setSuccessAlert('User successfully logged in');
                dispatch(setUserAuth(authUser.user));
                setSession(authUser);
                dispatch(setUser(authUser.user));
            } catch (error: any) {
                console.log(error);
                if (error.response.status === 400 && error.response.data === 'User not found') {
                    setRegisterError(error.response.data);
                } else {
                    setLoginError('Login error, please try again later');
                }
            }
        }

    };
    return <>
        <Grid container direction="column" spacing={2} alignItems="center" marginTop='10%'>
            <Grid item>
                <Typography variant="h5" gutterBottom>
                    Hi, Good to see you
                </Typography>
            </Grid>
            <Grid item>
                <EmailInput
                    value={loginUser.email}
                    onChange={handleChange}
                    error={emailError}
                />
            </Grid>
            <Grid item>
                <PasswordInput
                    value={loginUser.password}
                    onChange={handleChange}
                    error={passwordError}
                />
            </Grid>
            <Grid item>
                {loginError && (
                    <Typography variant="body2" color="error">
                        {loginError}
                    </Typography>
                )}
            </Grid>
            <Grid item>
                {registerError && (
                    <Typography variant="body2" color="error">
                        {registerError}
                    </Typography>
                )}
            </Grid>
            <Grid item>
                <Button
                    variant="contained"
                    endIcon={<SendIcon />}
                    fullWidth
                    onClick={handleSubmit}>
                    SignIn
                </Button>
            </Grid>
            <Grid item>
                <Typography variant="body1" color="textSecondary">
                    dont have an account?  <Link href={PATHS.join} color="inherit">     to register  </Link>
                </Typography>
            </Grid>
            {successAlert && (< SuccessAlert text={successAlert} />)}

        </Grid>
    </>
}
