
import { FormHelperText, FormControl, InputLabel, MenuItem, Select, SelectChangeEvent } from '@mui/material';
import { useEffect, useState } from 'react';
import { useAppDispatch as useDispatch, useAppSelector as useSelector } from '../../redux/store';
import { getCategories as getCategoriesApi } from '../../services/categories.service';
import { CategoryType } from '../../types/categories.types';
import { selectCategories } from '../../redux/categories/categories.selectors';
import { setCategories } from '../../redux/categories/categories.slice';

type SelectCategoryProps = {
    onSelectCategory: (categoryId: number) => void
}

export default function SelectCategory(p: SelectCategoryProps) {

    const [selectedCategory, setSelectedCategory] = useState<CategoryType>();

    const categories = useSelector(selectCategories)

    const dispatch = useDispatch()

    useEffect(() => {
        async function getCategories() {
            try {
                const categories = await getCategoriesApi();
                dispatch(setCategories(categories));
            } catch (error) {
                console.log(error);
            }
        }

        if (categories.length === 0) {
            getCategories();
        }
    }, []);



    const handleChange = (event: SelectChangeEvent<number>) => {
        const selectedCategory = categories.find(
            (c) => c.categoryId === event.target.value
        );
        setSelectedCategory(selectedCategory);
        if (selectedCategory !== undefined) {
            p.onSelectCategory(selectedCategory.categoryId);
        }
    };


    return (<>
        <FormControl sx={{ m: 1, minWidth: 80 }}>
            <InputLabel id="demo-simple-select-autowidth-label">סוג הטיול</InputLabel>
            <Select
                labelId="demo-simple-select-autowidth-label"
                id="demo-simple-select-autowidth"
                value={selectedCategory?.categoryId}
                autoWidth
                label="סוג הטיול"
                onChange={handleChange}>

                {categories.map((c) => (
                    <MenuItem key={c.categoryId} value={c.categoryId}>
                        {c.categoryName}
                    </MenuItem>
                ))}
            </Select>
            <FormHelperText>בחר את סוג הטיול הרצוי</FormHelperText>
        </FormControl>
    </>
    );
}
