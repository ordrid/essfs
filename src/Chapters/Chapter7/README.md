# Score Predictor

The rules:

- 300 points for predicting the correct score (e.g. 2-3 vs 2-3)
- 100 points for predicting the correct result (e.g. 2-3 vs 0-2)
- 15 points per home goal and 20 points per away goal using the lower of the predicted and actual scores

## Sample predictions and calculations

| Prediction | Actual Score | Points | Points Calculation              |
| ---------- | ------------ | ------ | ------------------------------- |
| (0, 0)     | (0, 0)       | 400    | 300 + 100 + (0 * 15) + (0 * 20) |
| (3, 2)     | (3, 2)       | 485    | 300 + 100 + (3 * 15) + (2 * 20) |
| (5, 1)     | (4, 3)       | 180    | 0 + 100 + (4 * 15) + (1 * 20)   |
| (2, 1)     | (0, 7)       | 20     | 0 + 0 + (0 * 15) + (1 * 20)     |
| (2, 2)     | (3, 3)       | 170    | 0 + 100 + (2 * 15) + (2 * 20)   |