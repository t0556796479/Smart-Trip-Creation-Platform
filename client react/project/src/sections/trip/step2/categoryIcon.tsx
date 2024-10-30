
import { Map,Restaurant, Attractions, Place } from '@mui/icons-material';

type CategoryIconProps = {
    categoryId: number | undefined
}

export default function CategoryIcon(props: CategoryIconProps) {
    let IconComponent;

    switch (props.categoryId) {
        case 1:
            IconComponent = Attractions;
            break;
        case 2:
            IconComponent = Map;
            break;
        case 3:
            IconComponent = Place;
            break;
        case 4:
            IconComponent = Restaurant;
            break;
        default:
            IconComponent = null;
            break;
    }

    return (
        <>
            {IconComponent ? <IconComponent /> : null}
        </>
    );
}


