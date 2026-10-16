
        // POST: api/enrolments
        [HttpPost]
        [Authorize(Roles = "Participant")]
        public async Task<IActionResult> CreateEnrolment(
            Enrolment enrolment)
        {
            var userId = User.FindFirstValue(
                ClaimTypes.NameIdentifier);

            if (!int.TryParse(userId, out int participantId))
                return Unauthorized();

            var category = await _db.Categories
                .FirstOrDefaultAsync(c =>
                    c.CategoryID == enrolment.CategoryID);

            if (category == null)
                return BadRequest(new
                {
                    message = "Category does not exist."
                });

            var eventItem = await _db.Events
                .FirstOrDefaultAsync(e =>
                    e.EventID == category.EventID);

            if (eventItem == null)
                return BadRequest(new
                {
                    message = "The event for this category does not exist."
                });

            if (eventItem.EventDate <= DateTime.Now)
                return BadRequest(new
                {
                    message = "Enrolment is closed because the event has started or passed."
                });

            var alreadyEnrolled = await _db.Enrolments
                .AnyAsync(e =>
                    e.UserID == participantId &&
                    e.CategoryID == enrolment.CategoryID);

            if (alreadyEnrolled)
                return Conflict(new
                {
                    message = "You are already enrolled in this category."
                });

            enrolment.EnrolmentID = 0;
            enrolment.UserID = participantId;
            enrolment.EnrolmentDate = DateTime.Now;

            _db.Enrolments.Add(enrolment);
            await _db.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetEnrolment),
                new { id = enrolment.EnrolmentID },
                enrolment);
        }
