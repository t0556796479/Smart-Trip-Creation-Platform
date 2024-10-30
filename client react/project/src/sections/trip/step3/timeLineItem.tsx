import { TimelineConnector, TimelineContent, TimelineDot, TimelineItem, TimelineOppositeContent, TimelineSeparator } from "@mui/lab";
import { Typography } from "@mui/material";
import { ReactNode } from "react";



type TripTimelineItemProps = {
    timelineOppositeContent: string,
    color: "inherit" | "grey" | "primary" | "secondary" | "error" | "info" | "success" | "warning" | undefined,
    icon: ReactNode,
    tripName: String,
    description: string,
    isRight: boolean
}

export default function TripTimelineItem(p: TripTimelineItemProps) {
    return (
        <>
            <TimelineItem>
                {/* {הכיתוב בצד} */}
                <TimelineOppositeContent
                    sx={{ m: 'auto 0' }}
                    align="right"
                    variant="body2"
                >
                    {p.timelineOppositeContent}
                </TimelineOppositeContent>
                <TimelineSeparator>
                    <TimelineConnector />
                    {/* הנקודה */}
                    <TimelineDot color={p.color}>
                        {/* האיקון */}
                        {p.icon}
                    </TimelineDot >
                    <TimelineConnector />
                </TimelineSeparator>
                <TimelineContent sx={{ py: '12px', px: 2 }}>
                    <Typography variant="h6" component="span">
                        {p.tripName}
                    </Typography>
                    <Typography>{p.description}</Typography>
                </TimelineContent>
            </TimelineItem>
        </>
    );
}

