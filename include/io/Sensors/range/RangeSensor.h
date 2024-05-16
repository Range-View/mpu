#include "../Sensor.h"
#include <string>
#include "DepthMatrix.h" 
#include "../../../enums/AxisDirection.h"

class RangeSensor : public ISensor {
private:
    DepthMatrix depthData;

public:
    RangeSensor() : depthData(getIninitialMatrixSize(AxisDirection::Vertical), getIninitialMatrixSize(AxisDirection::Horizontal)) {
        depthData.populateWithDummyData(true);
    }

    std::string readData() override {
        //return depthData.toString();  // for debugging
        return depthData.toClusterString();  // for debugging
    }

    void writeData(const std::string& data) override {

    }


private:
    size_t getIninitialMatrixSize(AxisDirection direction) {
        switch (direction) {
        case AxisDirection::Horizontal:
            return 60;
        case AxisDirection::Vertical:
            return 40;
        default:
            return 600;
        }
    }

    std::pair<size_t, size_t> getCurrentMatrixSize() {
        return std::make_pair(depthData.getRows(), depthData.getCols());
    }

};
