import { Container, Toolbar, AppBar } from '@mui/material';
import UserMenu from '../../sections/home/userMenu';
import NavMenue from '../../sections/home/navMenu';
import DisplayVideo from '../../sections/home/displayVideo';


export default function Home() {
  return (<>
    <AppBar position="static">
      <Container maxWidth="xl">
        <Toolbar disableGutters>
          <NavMenue />
          <UserMenu />
        </Toolbar>
      </Container>
    </AppBar>
    <DisplayVideo />
  </>
  );
}
