import Timeline from '@mui/lab/Timeline';
import TimelineItem from '@mui/lab/TimelineItem';
import TimelineSeparator from '@mui/lab/TimelineSeparator';
import TimelineConnector from '@mui/lab/TimelineConnector';
import TimelineContent from '@mui/lab/TimelineContent';
import TimelineOppositeContent from '@mui/lab/TimelineOppositeContent';
import TimelineDot from '@mui/lab/TimelineDot';
import FastfoodIcon from '@mui/icons-material/Fastfood';
import LaptopMacIcon from '@mui/icons-material/LaptopMac';
import HotelIcon from '@mui/icons-material/Hotel';
import RepeatIcon from '@mui/icons-material/Repeat';
import Typography from '@mui/material/Typography';
import { useEffect, useState } from 'react';
import { TripObjectType } from '../../../types/tripObject.types';
import { useAppDispatch as useDispatch, useAppSelector as useSelector } from '../../../redux/store'
import { selectAlgo } from '../../../redux/algorithem/algo.selectors';
import { GetRoute as GetRouteApi } from '../../../services/algorithem.service';
import CategoryIcon from '../step2/categoryIcon';
import TripTimelineItem from './timeLineItem';

const colors: ("inherit" | "grey" | "primary" | "secondary" | "error" | "info" | "success" | "warning")[] = ['primary', 'info', 'secondary'];
const booleanValues: boolean[] = [true, false];

export default function Step3() {

    const [algorithemResult, setAlgorithemResult] = useState<TripObjectType[] | null>();
    const algorithem = useSelector(selectAlgo)


    useEffect(() => {
        async function getAlgorithem() {
            try {
                console.log(algorithem);
                const algoResult = await GetRouteApi(algorithem);
                setAlgorithemResult(algoResult);
            } catch (error) {
                console.log(error);
            }
        }

        getAlgorithem();
    }, [])

    return (
        <Timeline position="alternate">
            {algorithemResult?.map((trip, index) => (
                <TripTimelineItem
                    timelineOppositeContent={`${trip.location}`}
                    color={colors[index % colors.length]}
                    icon={<CategoryIcon categoryId={trip.categoryId} />}
                    tripName={trip.tripName}
                    description={trip.description}
                    isRight={booleanValues[index % booleanValues.length]}
                />
            ))}
        </Timeline>
    );
}
