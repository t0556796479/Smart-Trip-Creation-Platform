import * as React from 'react';
import Box from '@mui/material/Box';
import Stepper from '@mui/material/Stepper';
import Step from '@mui/material/Step';
import StepLabel from '@mui/material/StepLabel';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import Step2 from '../../sections/trip/step2/step2';
import Step1 from '../../sections/trip/step1/step1';
import Step3 from '../../sections/trip/step3/step3';
import { useNavigate } from 'react-router-dom';
import { PATHS } from '../../routes/paths';
// import Step3 from '../../sections/trip/step3/Step3';

type Step = {
    label: string;
    image: string;
    element: React.ReactNode;
}

const steps: Step[] = [{
    label: 'Step 1',
    image: '/images/step1img.png',
    element: <Step1 />
}, {
    label: 'Step 2',
    image: '/images/step2img.png',
    element: <Step2 />
}, {
    label: 'Step 3',
    image: '/images/step3img.png',
    element: <Step3 />
},];

export default function MainStepper() {
    const [activeStep, setActiveStep] = React.useState(0);
    const [skipped, setSkipped] = React.useState(new Set<number>());

    const navigate=useNavigate();

    const isStepSkipped = (step: number) => {
        return skipped.has(step);
    };

    const handleNext = () => {
        let newSkipped = skipped;
        if (isStepSkipped(activeStep)) {
            newSkipped = new Set(newSkipped.values());
            newSkipped.delete(activeStep);
        }

        setActiveStep((prevActiveStep) => prevActiveStep + 1);
        setSkipped(newSkipped);
    };

    const handleBack = () => {
        setActiveStep((prevActiveStep) => prevActiveStep - 1);
    };

    const handleReset = () => {
        setActiveStep(0);
    };

    function handleHome(): void {
        navigate(PATHS.home);
    }

    return (
        <Box sx={{ width: '100%' }}>
            <Stepper activeStep={activeStep}>
                {steps.map((step, index) => {
                    const stepProps: { completed?: boolean } = {};
                    const labelProps: {} = {};
                    if (isStepSkipped(index)) {
                        stepProps.completed = false;
                    }
                    return (
                        <Step key={index} {...stepProps}>
                            <StepLabel {...labelProps}>{step.label}</StepLabel>
                        </Step>
                    );
                })}
            </Stepper>
            {activeStep === steps.length ? (
                <React.Fragment>
                    <Typography sx={{ mt: 2, mb: 1 }}>
                        All steps completed - you&apos;re finished
                    </Typography>
                    <Box sx={{ display: 'flex', flexDirection: 'row', pt: 2 }}>
                        <Box sx={{ flex: '1 1 auto' }} />
                        <Button onClick={handleReset}>Reset</Button>
                    </Box>
                </React.Fragment>
            ) : (
                <React.Fragment>
                    <Box sx={{ mt: 2, mb: 1, textAlign: 'center' }}>
                        <img 
                            src={steps[activeStep].image} 
                            alt={steps[activeStep].label} 
                            style={{ maxWidth: '80%', height: 'auto', maxHeight: '300px', borderRadius: '8px' }} 
                        />
                        <Typography>{steps[activeStep].element}</Typography>
                    </Box>
                    <Box sx={{ display: 'flex', flexDirection: 'row', pt: 2 }}>
                        <Button
                            color="inherit"
                            disabled={activeStep === 0}
                            onClick={handleBack}
                            sx={{ mr: 1 }}
                        >
                            Back
                        </Button>
                        <Box sx={{ flex: '1 1 auto' }} />
                        <Button onClick={handleNext}>
                            {activeStep === steps.length - 1 ? 'Finish' : 'Next'}
                        </Button>
                    </Box>
                </React.Fragment>
            )}
        </Box>
    );
}
