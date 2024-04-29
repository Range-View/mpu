#pragma once
#include <string>

class ISensor {
public:
    virtual ~ISensor() = default;

    // Read data from the sensor
    virtual std::string readData() = 0;

    // Write data to the sensor
    virtual void writeData(const std::string& data) = 0;
};
