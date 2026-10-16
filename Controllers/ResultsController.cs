        // Organiser can record a race result
        [HttpPost]
        [Authorize(Roles = "Organiser")]
        public async Task<IActionResult> CreateResult(Result result)
        {
            var enrolmentExists = await _db.Enrolments
                .AnyAsync(e => e.EnrolmentID == result.EnrolmentID);

            if (!enrolmentExists)
            {
                return BadRequest(new
                {
                    message = "Enrolment does not exist."
                });
            }

            if (result.FinishTime < TimeSpan.Zero)
            {
                return BadRequest(new
                {
                    message = "Finish time cannot be negative."
                });
            }

            if (result.Position < 1)
            {
                return BadRequest(new
                {
                    message = "Position must be at least 1."
                });
            }

            var validStatuses = new[] { "Finished", "Did Not Finish", "Disqualified" };

            if (!validStatuses.Contains(result.Status))
            {
                return BadRequest(new
                {
                    message = "Status must be Finished, Did Not Finish, or Disqualified."
                });
            }

            var resultExists = await _db.Results
                .AnyAsync(r => r.EnrolmentID == result.EnrolmentID);

            if (resultExists)
            {
                return Conflict(new
                {
                    message = "A result already exists for this enrolment."
                });
            }

            result.ResultID = 0;

            _db.Results.Add(result);
            await _db.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetResults),
                new { id = result.ResultID },
                result);
        }
