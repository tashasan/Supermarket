import { toast, ToastContainer } from "react-toastify";
import { AlertType } from "../utils/ComponentEnums";

function HandleAlert(message, type) {
    let alert = ""
    switch (type) {
        case AlertType.Success:
            alert = toast.success(message);
            break;
        case AlertType.Info:
            alert = toast.info(message);
            break;
        case AlertType.Warning:
            alert = toast.warning(message);
            break;
        case AlertType.Error:
            alert = toast.error(message);
            break;
        default:
            alert = "";
    }

    return (
        <div> {alert !== "" ? alert : null}
            <ToastContainer
                limit={1}
                position={"top-center"}
                autoClose={2000}
                closeOnClick
                theme="light" />
        </div>
    );

}
export default HandleAlert;