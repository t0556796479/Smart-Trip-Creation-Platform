
import { Dialog } from '@mui/material';
import { useState } from 'react';
import SelectCategory from '../../../components/select/selectCategory';
import AgendaList from './agendaList';
import { useAppDispatch as useDispatch, useAppSelector as useSelector } from '../../../redux/store'
import { addStepToAgenda } from '../../../redux/algorithem/algo.slice';
import { AgendaStepType } from '../../../types/agendaStep.type';
import CategoryProperties from '../../../components/select/selectCategoryProperties';


export default function Step2() {

    const dispatch = useDispatch();

    const [open, setOpen] = useState(false);
    const [categoryId, setCategoryId] = useState<number>();


    const handleClickOpen = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };

    const handleCatrgorySelect = (categoryId: number) => {
        setCategoryId(categoryId);
    }

    const handleClickOk = (agendaStep: AgendaStepType) => {
        dispatch(addStepToAgenda(agendaStep));

    };

    return (<>
        <Dialog onClose={handleClose} open={open} maxWidth="lg" // Set the maximum width of the dialog
            fullWidth // Ensure the dialog uses the full width up to the maxWidth
            PaperProps={{
                style: {
                    margin: '20px', // Adjust the margin to create the desired spacing around the dialog
                    width: 'calc(100% - 40px)', // Calculate the width to maintain margins
                    height: 'calc(100% - 40px)', // Calculate the height to maintain margins
                },
            }} >
            <SelectCategory onSelectCategory={handleCatrgorySelect} />
            <CategoryProperties onClick={handleClickOk} onClose={handleClose} selectedCategoryId={categoryId} />
        </Dialog>
        <AgendaList onAddIconClick={handleClickOpen} />
    </>
    );
}

