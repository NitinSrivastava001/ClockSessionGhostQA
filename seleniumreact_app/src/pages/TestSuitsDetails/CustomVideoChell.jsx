import React, { useState } from "react";
import TableCell from "@material-ui/core/TableCell";
import Modal from "@material-ui/core/Modal";
import Box from "@material-ui/core/Box";
import VideocamIcon from "@mui/icons-material/Videocam";
import ClearOutlinedIcon from "@mui/icons-material/ClearOutlined";
import { Icon } from "@material-ui/core";

const CustomVideoChell = ({ row }) => {
  const [openModal, setOpenModal] = useState(false);
  //const baseUrl = "https://codearrest.dyndns.org:3005";
  const getVideoUrl = (apiPath) => {
    return `${apiPath?.replace(/\\/g, '/')}`;
  };
  console.log("row+++video", row);
  console.log("getVideoUrl", getVideoUrl(row.TestCaseVideoURL));
  const handleOpenModal = () => {
    setOpenModal(true);
  };

  const handleCloseModal = () => {
    setOpenModal(false);
  };

  return (
    <>
      <TableCell>
        <Icon
          component={VideocamIcon}
          style={{ color: "rgb(25, 118, 210)" }}
          onClick={handleOpenModal}
        />
      </TableCell>

      {/* Modal for displaying the full image */}
      <Modal
        open={openModal}
        onClose={handleCloseModal}
        aria-labelledby="image-modal-title"
        aria-describedby="image-modal-description"
        style={{
          display: "flex",
          alignItems: "center",
          justifyContent: "center",
        }}
      >
        <div
          style={{
            backgroundColor: "white",
            borderRadius: "8px",
            overflow: "hidden",
          }}
        >
          <Box
            sx={{
              maxWidth: "60vw",
              position: "relative",
            }}
          >
            <video
              autoPlay
              muted
              controls
              style={{ width: "100%", height: "100%", objectFit: "contain" }}
            >
              <source
                src={getVideoUrl(row.TestCaseVideoURL)}
                type="video/mp4"
              />
            </video>
            <Box
              onClick={handleCloseModal}
              sx={{
                cursor: "pointer",
                position: "absolute",
                top: "10px",
                right: "10px",
                height: "20px",
                color: "rgb(25, 118, 210)",
              }}
            >
              <ClearOutlinedIcon />
            </Box>
          </Box>
        </div>
      </Modal>
    </>
  );
};

export default CustomVideoChell;