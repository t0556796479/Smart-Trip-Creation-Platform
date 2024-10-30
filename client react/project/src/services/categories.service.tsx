import { CategoryType } from '../types/categories.types'
import axios from '../utils/axios'

export const getCategories = async () => {
    const response = await axios.get('/Categories')
    const categories = await response.data
    return categories
}

export const getCategoryById = async (id:Number) => {
    const response = await axios.get(`/Categories/${id}`)
    const category = response.data
    return category
}

export const addCategory = async (category:Omit<CategoryType, 'categoryId'>) => {
    const response = await axios.post('/Categories', category)
    const newCategory = response.data
    return newCategory
}

export const updateCategory = async (category: CategoryType, id: number) => {
    const response = await axios.put(`/Categories/${id}`, category)
    const updatedCategory = response.data
    return updatedCategory
}

export const deleteCategory = async (id: number) => {
    const response = await axios.delete(`/Categories/${id}`)
    return response
}

