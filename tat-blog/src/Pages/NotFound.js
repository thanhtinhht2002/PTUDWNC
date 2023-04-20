
import { p1 as p1 } from "react-bootstrap";
const NotFound = () => {
  return (
    <>
    <p1
      collapseOnSelect
      expand="sm"
      bg="white"
      variant="light"
      className="border-bottom shadow"
    >
      <h1>404</h1>
      <div>
        <h3><p1>Chà!</p1> Không tìm thấy trang rồi.</h3>
      </div>
      <div>
        <span>Trang mà bạn tìm không tồn tại.</span>
      </div>
      <button>Về trang chủ thôi!</button>
    </p1>  
    </>
  );
};
export default NotFound;
