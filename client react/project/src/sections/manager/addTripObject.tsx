import React, { ChangeEvent, useEffect, useState } from 'react';
import { TextField, Button, Select, MenuItem, FormControl, InputLabel, FormHelperText, SelectChangeEvent, Grid, Dialog, Container } from '@mui/material';
import SelectArea from '../../components/select/selectArea';
import SelectCategory from '../../components/select/selectCategory';
import CategoryProperties from '../../components/select/selectCategoryProperties';
import { AgendaStepType } from '../../types/agendaStep.type';
import AutoComplete from '../../components/googleMaps/autoComplete';
import { PointType } from '../../types/algorithem.type';
import { TripObjectType } from '../../types/tripObject.types';
import { addTripObject as addTripObjectApi } from '../../services/tripObject.service';
import SuccessAlert from '../../components/alert/successAlert';
import ErrorAlert from '../../components/alert/errorAlert';

export default function AddTripObject() {

    const [open, setOpen] = React.useState(false);


    const [tripName, setTripName] = useState('');
    const [tripDescription, setTripDescription] = useState('');
    const [tripAreaId, setTripAreaId] = useState(0);
    const [tripCategoryId, setTripCategoryId] = useState(0);
    const [propertiesList, setPropertiesList] = useState<number[] | undefined>([]);
    const [tripLat, setTripLat] = useState<number>(0);
    const [tripLng, setTripLng] = useState<number>(0);
    const [tripLocation, setTripLocation] = useState<string>('');


    const handleTripNameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setTripName(event.target.value);
    };

    const handleTripDescriptionChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setTripDescription(event.target.value);
    };

    const handleAreaSelect = (areaId: number) => {
        setTripAreaId(areaId);
    }

    const handleCatrgorySelect = (categoryId: number) => {
        setTripCategoryId(categoryId);
    };

    const handleClickOk = (value: AgendaStepType) => {
        setPropertiesList(value.propertiesIdList);

    }


    const handleSubmit = async () => {

        const new_tripObject: Omit<TripObjectType, "tripId"> = {
            tripName: tripName,
            description: tripDescription,
            categoryId: tripCategoryId,
            areaId: tripAreaId,
            propertiesList: propertiesList,
            lat: tripLat,
            lng: tripLng,
            location: tripLocation
        }
        try {
            const response = await addTripObjectApi(new_tripObject);
        }
        catch (error) {
            console.error('Error sending data:', error);
        }

    };

    const handleClickOpen = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };


    const handlePointSelect = (point: PointType) => {
        setTripLat(point.lat);
        setTripLng(point.lng);
        setTripLocation(point.location);
    };

    return (
        <Container maxWidth="sm">

            <form onSubmit={handleSubmit}>
                <Grid container spacing={3}>
                    <Grid item xs={12}>
                        <TextField
                            label="שם הטיול"
                            value={tripName}
                            onChange={handleTripNameChange}
                            required
                            fullWidth
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <TextField
                            label="תיאור הטיול"
                            value={tripDescription}
                            onChange={handleTripDescriptionChange}
                            required
                            fullWidth
                            multiline
                            rows={6}
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <SelectArea onSelectArea={handleAreaSelect} />
                    </Grid>
                    <Grid item xs={12}>
                        <Dialog onClose={handleClose} open={open} maxWidth="lg"
                            fullWidth
                            PaperProps={{
                                style: {
                                    margin: '20px',
                                    width: 'calc(100% - 40px)',
                                    height: 'calc(100% - 40px)',
                                },
                            }} >
                            <SelectCategory onSelectCategory={handleCatrgorySelect} />
                            <CategoryProperties onClick={handleClickOk} onClose={handleClose} selectedCategoryId={tripCategoryId} />

                        </Dialog>
                        <Button variant="outlined" onClick={handleClickOpen}>
                            Select trip properties
                        </Button>
                    </Grid>
                    <Grid item xs={12}>
                        <AutoComplete onSelectLocation={handlePointSelect} lable="loction" />
                    </Grid>
                    <Grid item xs={12}>
                        <Button type="submit" variant="contained" color="primary" fullWidth>
                            ADD
                        </Button>
                    </Grid>
                </Grid>
            </form>
        </Container >
    );
};

