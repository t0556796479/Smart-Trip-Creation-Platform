import { PATHS } from '../../routes/paths';
import { MenuItem, Tooltip, Link, Avatar, Menu, Typography, IconButton, Box } from '@mui/material';
import { useEffect, useState } from 'react';
import { useAppSelector } from '../../redux/store';
import { selectAuth } from '../../redux/auth/auth.selectors';

export type SettingType = {
    key: number,
    name: string,
    path: string
}

const authSettings: SettingType[] = [
    { key: 1, name: 'Profile', path: PATHS.profile },
    { key: 2, name: 'Logout', path: PATHS.logout }
];

const managerSetting: SettingType[] = [
    { key: 1, name: 'Profile', path: PATHS.profile },
    { key: 2, name: 'Logout', path: PATHS.logout },
    { key: 3, name: 'manager', path: PATHS.manager }
];

const gustSettings: SettingType[] = [
    { key: 1, name: 'Sign-in', path: PATHS.signIn },
    { key: 2, name: 'Join', path: PATHS.join }
];

export default function UserMenu() {

    const [settings, setSettings] = useState<SettingType[]>();

    const authState = useAppSelector(selectAuth);

    useEffect(() => {
        if (authState.user?.role === "manager") {
            setSettings(managerSetting);
        }
        else {
            if (!authState.user) {
                setSettings(gustSettings);
            }
            else {
                setSettings(authSettings);
            }
        }
    });


    const [anchorElUser, setAnchorElUser] = useState<null | HTMLElement>(null);


    const handleOpenUserMenu = (event: React.MouseEvent<HTMLElement>) => {
        setAnchorElUser(event.currentTarget);
    };

    const handleCloseUserMenu = () => {
        setAnchorElUser(null);
    };


    return (
        <>
            <Box sx={{ flexGrow: 0 }}>
                <Tooltip title="Open settings">
                    {/* {הוסתפ תמונת פרופיל} */}
                    <IconButton onClick={handleOpenUserMenu} sx={{ p: 0 }}>
                        <Avatar alt="Remy Sharp" src="" />
                        {authState.isAuthanticated &&
                            <Typography
                                variant="body1"
                                sx={{
                                    marginLeft: 1,
                                    color: 'white'

                                }}>
                                Hi {authState.user?.name}
                            </Typography>}
                    </IconButton>
                </Tooltip>
                <Menu
                    sx={{ mt: '45px' }}
                    id="menu-appbar"
                    anchorEl={anchorElUser}
                    anchorOrigin={{
                        vertical: 'top',
                        horizontal: 'right',
                    }}
                    keepMounted
                    transformOrigin={{
                        vertical: 'top',
                        horizontal: 'right',
                    }}
                    open={Boolean(anchorElUser)}
                    onClose={handleCloseUserMenu}
                >
                    {settings?.map((setting) => (
                        <MenuItem key={setting.key}>
                            <Typography textAlign="center">
                                <Link href={setting.path} color="inherit">{setting.name}</Link>
                            </Typography>
                        </MenuItem>
                    ))}
                </Menu>
            </Box>
        </>
    );
}
