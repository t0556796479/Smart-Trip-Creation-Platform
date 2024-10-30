import { FilterType } from '../types/filters.types'
import axios from '../utils/axios'

export const getFilters = async () => {
    const response = await axios.get('/Filters')
    const filters = await response.data
    return filters
}

export const getFilterById = async (id:Number) => {
    const response = await axios.get(`/Filters/${id}`)
    const filter = response.data
    return filter
}

export const addFilter = async (filter:Omit<FilterType, 'filterId'>) => {
    const response = await axios.post('/Filters', filter)
    const newFilter = response.data
    return newFilter
}

export const updateFilter = async (filter: FilterType, id: number) => {
    const response = await axios.put(`/Filters/${id}`, filter)
    const updatedFilter = response.data
    return updatedFilter
}

export const deleteFilter = async (id: number) => {
    const response = await axios.delete(`/Filters/${id}`)
    return response
}

