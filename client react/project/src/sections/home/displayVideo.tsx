import { Box } from '@mui/material';

export default function DisplayVideo() {
    return (
        <Box sx={{ mt: 2 }}>
            <Box
                sx={{
                    position: 'relative',
                    paddingBottom: '56.25%', 
                    height: 0,
                    overflow: 'hidden',
                    width: '100%',
                    background: '#000',
                    mb: 2
                }}
            >
                <video
                    className='videoBox'
                    src='/videos/display_video.mp4'
                    autoPlay
                    controls={false}
                    loop
                    muted
                    style={{
                        position: 'absolute',
                        top: 0,
                        left: 0,
                        width: '100%',
                        height: '100%'
                    }}
                >
                    הדפדפן שלך אינו תומך באלמנט הווידאו.
                </video>
            </Box>
        </Box>
    );
}
