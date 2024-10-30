import { FormControl, FormHelperText, Input, InputAdornment } from "@mui/material"
import { Email as EmailIcon } from "@mui/icons-material";
import { ChangeEvent } from "react";

export type EmailInputProps = {
    value: string;
    onChange: (event: ChangeEvent<HTMLInputElement>) => void;
    error: string;
}

export default function EmailInput({ value, onChange, error }: EmailInputProps) {
    return (
        <>
            <FormControl variant="outlined" sx={{ m: 1, mt: 3, width: '25ch' }} error={!!error}>
                <Input
                    id="email-input"
                    name="email"
                    value={value}
                    onChange={onChange}
                    endAdornment={<InputAdornment position="end"><EmailIcon /></InputAdornment>}
                    aria-describedby="email-error-text" inputProps={{
                        'aria-label': 'email',
                    }}
                />
                <FormHelperText id="standard-weight-helper-text">Email</FormHelperText>
                {error && <FormHelperText id="email-error-text">{error}</FormHelperText>}
            </FormControl>
        </>
    )
}