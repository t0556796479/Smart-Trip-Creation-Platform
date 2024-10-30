import { styled } from '@mui/material/styles';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import CssBaseline from '@mui/material/CssBaseline';
import Toolbar from '@mui/material/Toolbar';
import Paper from '@mui/material/Paper';
import Fab from '@mui/material/Fab';
import List from '@mui/material/List';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemAvatar from '@mui/material/ListItemAvatar';
import ListItemText from '@mui/material/ListItemText';
import Avatar from '@mui/material/Avatar';
import AddIcon from '@mui/icons-material/Add';
import { Fragment, useEffect, useState } from 'react';
import { AgendaStepType } from '../../../types/agendaStep.type';
import { useAppSelector as useSelector } from '../../../redux/store'
import { selectAlgo } from '../../../redux/algorithem/algo.selectors';
import CategoryIcon from './categoryIcon';

type AgendaListProps = {
    onAddIconClick: () => void,
}
export default function AgendaList(p: AgendaListProps) {

    const agendaStepsSelector = useSelector(selectAlgo);

    const [agendaSteps, setAgendaSteps] = useState<AgendaStepType[] | null>();
    useEffect(() => {
        setAgendaSteps(agendaStepsSelector.agenda)
    })

    return (
        <Box>
            <Paper square sx={{ pb: '50px', position: 'fixed',  left: '25%', width: '50%', zIndex: 1 }}>
                <List sx={{ mb: 2 }}>
                    {agendaSteps?.map((a) => (
                        <Fragment key={a.id}>
                            <ListItemButton>
                                <ListItemAvatar>
                                    <Avatar>
                                        < CategoryIcon categoryId={a.categoryId} />
                                    </Avatar>
                                </ListItemAvatar>
                                <ListItemText primary={a.filterName} secondary={a.propertyName} />
                            </ListItemButton>
                        </Fragment>
                    ))}
                </List>
                <AddIcon color="secondary" onClick={p.onAddIconClick} />
            </Paper>
        </Box>
    );
}