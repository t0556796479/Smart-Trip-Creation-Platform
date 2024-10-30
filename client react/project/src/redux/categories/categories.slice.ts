import { PayloadAction, createSlice } from '@reduxjs/toolkit'
import { CategoriesStateType, CategoryType } from '../../types/categories.types'; 

const categoriesSlice = createSlice({
    name: 'categories',
    initialState: { categories: [] } as CategoriesStateType,
    reducers: {
        setCategories: (state: CategoriesStateType, action: PayloadAction<CategoryType[]>) => {
            state.categories = action.payload;
        },
        addCategories: (state: CategoriesStateType, action: PayloadAction<CategoryType>) => {
            state.categories.push(action.payload)
        },
        deleteCategories: (state: CategoriesStateType, action: PayloadAction<number>) => {
            state.categories = state.categories.filter(c => c.categoryId !== action.payload)
        },
        updateCategories: (state: CategoriesStateType, action: PayloadAction<CategoryType>) => {
            const updateCategoryId = state.categories.findIndex(c => c.categoryId === action.payload.categoryId)
            state.categories[updateCategoryId] = action.payload
        }
    }
})

export const { addCategories, deleteCategories, updateCategories, setCategories } = categoriesSlice.actions

export default categoriesSlice.reducer