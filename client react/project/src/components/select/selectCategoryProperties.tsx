
import { Box, Button, Checkbox, FormControl, FormControlLabel, FormGroup, FormLabel } from '@mui/material';
import { useEffect, useState } from 'react';
import { useAppDispatch as useDispatch, useAppSelector as useSelector } from '../../redux/store'
import { addStepToAgenda, setAlgoAreaId } from '../../redux/algorithem/algo.slice';
import { FilterType } from '../../types/filters.types';
import { PropertyType } from '../../types/properties.types';
import { GetPropertiesByCategory as GetPropertiesByCategoryApi } from '../../services/algorithem.service';
import { AgendaStepType } from '../../types/agendaStep.type';
import { selectAlgoAgendaId } from '../../redux/algorithem/algoAgendaId.selector';
import algoAgendaIdSlice, { setAlgoAgendaId } from '../../redux/algorithem/algoAgendaId.slice';

type CategoryPropertiesProps = {
    selectedCategoryId: number | undefined
    onClose: () => void
    onClick: (value: AgendaStepType) => void
}
export type SelectedFilterType = {
    filter: FilterType,//הפילטר שנבחר
    property: PropertyType//והמאפין של הפילטר
}

export type FilterPropertiesType = {
    //לכל פילטר רשימה של מאפינים קשורים
    filter: FilterType,
    properties: PropertyType[]
}


export type SelectedPropertiesType = {
    [key: number /*filterId */]: number[] /*propertiesList */;
}

export default function CategoryProperties({ onClose, onClick, selectedCategoryId }: CategoryPropertiesProps) {

    const [catrgoryProperties, setCatrgoryProperties] = useState<FilterPropertiesType[]>()


    const [selectedFilter, setSelectedFilter] = useState<SelectedFilterType | null>(null);
    const [selectedProperties, setSelectedProperties] = useState<SelectedPropertiesType>({});
    const [tripId, setTripId] = useState(useSelector(selectAlgoAgendaId))



    const dispatch = useDispatch();

    useEffect(() => {
        async function setFiltersPropertiesListApi(categoryId: number) {
            const propertiesList = await GetPropertiesByCategoryApi(categoryId);
            setCatrgoryProperties(propertiesList);
        }

        if (selectedCategoryId !== undefined) {
            setFiltersPropertiesListApi(selectedCategoryId);
        }
    }, [selectedCategoryId]);

    const handleCheckboxChange = (filter: FilterType, property: PropertyType, isMultiSelect: boolean) => {
        if (isMultiSelect) {
            setSelectedProperties((prevState) => {
                const selectedSet = new Set(prevState[filter.filterId] || []);
                if (selectedSet.has(property.propertyId)) {
                    selectedSet.delete(property.propertyId);
                } else {
                    selectedSet.add(property.propertyId);
                }
                return {
                    ...prevState,
                    [filter.filterId]: Array.from(selectedSet),
                };
            });
        } else {
            setSelectedFilter({ filter, property });
        }
    };

    const isMultiSelectGroup = (filterName: string) => filterName === 'מאפיינים';

    const handleClickOk = () => {
        if (selectedFilter) {
            const propertiesList = [selectedFilter.property.propertyId].concat(Object.values(selectedProperties).flat());

            try {
                const agendaStep: AgendaStepType = {
                    id: tripId,
                    categoryId: selectedCategoryId,
                    filterName: selectedFilter.filter.filterName,
                    propertyName: selectedFilter.property.propertyName,
                    propertiesIdList: propertiesList
                }
                dispatch(setAlgoAgendaId());
                console.log(agendaStep.id)
                onClick(agendaStep);
            } catch (error) {
                console.log(error);
            }
        }
        onClose();
    };


    return (<>
        <FormControl>
            <Box sx={{ display: 'flex', flexWrap: 'wrap', gap: 2 }}>
                {catrgoryProperties?.map((f) => (
                    <Box key={f.filter.filterId} sx={{ minWidth: '200px' }}>
                        <div key={f.filter.filterId}>
                            <FormLabel>{f.filter.filterName}</FormLabel>
                            <FormGroup>
                                {f.properties.map((p) => (
                                    <FormControlLabel
                                        key={p.propertyId}
                                        control={
                                            <Checkbox
                                                checked={
                                                    isMultiSelectGroup(f.filter.filterName)
                                                        ? selectedProperties[f.filter.filterId]?.includes(p.propertyId)
                                                        : selectedFilter?.filter.filterId === f.filter.filterId && selectedFilter?.property.propertyId === p.propertyId
                                                }
                                                onChange={() => handleCheckboxChange(f.filter, p, isMultiSelectGroup(f.filter.filterName))}
                                            />
                                        }
                                        label={p.propertyName}
                                    />
                                ))}
                            </FormGroup>
                        </div>
                    </Box>
                ))}
            </Box>
        </FormControl>
        <Button onClick={handleClickOk}>אישור</Button>

    </>
    );
}
