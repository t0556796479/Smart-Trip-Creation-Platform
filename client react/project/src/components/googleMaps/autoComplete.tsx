import { TextField, Button, Box, Typography } from '@mui/material';
import { Autocomplete } from '@react-google-maps/api';
import { PointType } from '../../types/algorithem.type';
import { useRef, useState } from 'react';
import SuccessAlert from '../alert/successAlert';
import ErrorAlert from '../alert/errorAlert';

type AutoCompleteProps = {
    onSelectLocation: ({ lat, lng, location }: PointType) => void,
    lable: string
}

export default function AutoComplete({ onSelectLocation, lable }: AutoCompleteProps) {
    const placeAutocomplete = useRef<google.maps.places.Autocomplete | null>(null);
    const [selectedLocation, setSelectedLocation] = useState<PointType | null>();

    const [errorAlert, setErrorAlert] = useState<string>('');
    const [successAlert, setSuccessAlert] = useState<string>('');

    const handlePlaceSelect = (place: google.maps.places.PlaceResult) => {
        const selectedPos = {
            lat: place.geometry?.location?.lat() || 0,
            lng: place.geometry?.location?.lng() || 0,
            location: place.formatted_address || ''
        };
        setSelectedLocation(selectedPos);
    };

    const handleClick = () => {
        if (selectedLocation?.lat && selectedLocation?.lng && selectedLocation?.location) {
            onSelectLocation(selectedLocation);
            setErrorAlert('');
            setSuccessAlert("success");

        } else {
            setSuccessAlert('')
            setErrorAlert("Please select a valid location");
        }
    };

    return (
        <Box sx={{ p: 2, border: '1px dashed grey', mr: 2 }}>
            <Typography variant="overline" display="block" gutterBottom>
                {lable}
            </Typography>
            <div className="container mt-5">
                <div className="d-flex justify-content-center">
                    <div className="col-md-6">
                        <Autocomplete
                            onLoad={(autocomplete: google.maps.places.Autocomplete | null) => {
                                placeAutocomplete.current = autocomplete;
                            }}
                            onPlaceChanged={() => handlePlaceSelect(placeAutocomplete.current?.getPlace()!)}>
                            <TextField
                                type="text"
                                placeholder={lable}
                                fullWidth
                                InputProps={{
                                    style: {
                                        borderRadius: '3px',
                                        boxShadow: '0 2px 6px rgba(0, 0, 0, 0.3)',
                                    },
                                }}
                            />
                        </Autocomplete>

                        <div style={{ display: 'flex', justifyContent: 'center', marginTop: '16px' }}>
                            <Button variant="text" onClick={handleClick}>OK</Button>
                        </div>
                        {successAlert && (< SuccessAlert text={successAlert} />)}
                        {errorAlert && (< ErrorAlert text={errorAlert} />)}
                    </div>
                </div>
            </div>
        </Box>

    );
}
